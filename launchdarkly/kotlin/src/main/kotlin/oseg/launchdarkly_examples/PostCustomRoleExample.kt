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
class PostCustomRoleExample
{
    fun postCustomRole()
    {
        ApiClient.apiKey["ApiKey"] = "YOUR_API_KEY"

        val policy1 = StatementPost(
            effect = StatementPost.Effect.allow,
            resources = listOf (
                "proj/*:env/production:flag/*",
            ),
            actions = listOf (
                "updateOn",
            ),
        )

        val policy = arrayListOf<StatementPost>(
            policy1,
        )

        val customRolePost = CustomRolePost(
            name = "Ops team",
            key = "role-key-123abc",
            description = "An example role for members of the ops team",
            basePermissions = "reader",
            policy = policy,
        )

        try
        {
            val response = CustomRolesApi().postCustomRole(
                customRolePost = customRolePost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling CustomRolesApi#postCustomRole")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling CustomRolesApi#postCustomRole")
            e.printStackTrace()
        }
    }
}
