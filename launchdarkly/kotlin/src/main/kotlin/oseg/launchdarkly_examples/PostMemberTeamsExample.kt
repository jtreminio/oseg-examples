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
class PostMemberTeamsExample
{
    fun postMemberTeams()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val memberTeamsPostInput = MemberTeamsPostInput(
            teamKeys = listOf (
                "team1",
                "team2",
            ),
        )

        try
        {
            val response = AccountMembersApi().postMemberTeams(
                id = null,
                memberTeamsPostInput = memberTeamsPostInput,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AccountMembersApi#postMemberTeams")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AccountMembersApi#postMemberTeams")
            e.printStackTrace()
        }
    }
}
