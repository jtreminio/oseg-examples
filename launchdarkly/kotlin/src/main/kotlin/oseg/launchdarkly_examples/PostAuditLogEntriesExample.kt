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
class PostAuditLogEntriesExample
{
    fun postAuditLogEntries()
    {
        ApiClient.apiKey["Authorization"] = "YOUR_API_KEY"

        val statementPost1 = StatementPost(
            effect = StatementPost.Effect.allow,
            resources = listOf (
                "proj/*:env/*:flag/*;testing-tag",
            ),
            notResources = listOf (),
            actions = listOf (
                "*",
            ),
            notActions = listOf (),
        )

        val statementPost = arrayListOf<StatementPost>(
            statementPost1,
        )

        try
        {
            val response = AuditLogApi().postAuditLogEntries(
                before = null,
                after = null,
                q = null,
                limit = null,
                statementPost = statementPost,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling AuditLogApi#postAuditLogEntries")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling AuditLogApi#postAuditLogEntries")
            e.printStackTrace()
        }
    }
}
