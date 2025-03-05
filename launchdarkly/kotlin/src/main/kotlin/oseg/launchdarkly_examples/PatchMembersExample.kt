package oseg.launchdarkly_examples

import com.launchdarkly.client.infrastructure.*
import com.launchdarkly.client.apis.*
import com.launchdarkly.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class PatchMembersExample
{
    fun patchMembers()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val membersPatchInput = MembersPatchInput(
            instructions = Serializer.moshi.adapter<List<Map<String, Any>>>().fromJson("""
                [
                    {
                        "kind": "replaceMembersRoles",
                        "memberIDs": [
                            "1234a56b7c89d012345e678f",
                            "507f1f77bcf86cd799439011"
                        ],
                        "value": "reader"
                    }
                ]
            """)!!,
            comment = "Optional comment about the update",
        )

        try
        {
            val response = AccountMembersBetaApi().patchMembers(
                membersPatchInput = membersPatchInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountMembersBetaApi#patchMembers")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountMembersBetaApi#patchMembers")
            e.printStackTrace()
        }
    }
}
